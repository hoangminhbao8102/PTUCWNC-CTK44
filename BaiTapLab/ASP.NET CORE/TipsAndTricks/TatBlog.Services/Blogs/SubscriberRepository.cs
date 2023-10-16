using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Services.Extensions;

namespace TatBlog.Services.Blogs
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private readonly BlogDbContext _dbContext;

        public SubscriberRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task BlockSubscriberAsync(int id, string reason, string notes)
        {
            var subscriber = await GetSubscriberByIdAsync(id);

            if (subscriber != null)
            {
                subscriber.UnsubscribeDate = DateTime.Now;
                subscriber.UnsubscribeReason = reason;
                subscriber.AdminNote = notes;

                _dbContext.Subscribers.Update(subscriber);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteSubscriberAsync(int id)
        {
            var subscriber = await GetSubscriberByIdAsync(id);

            if (subscriber != null)
            {
                _dbContext.Subscribers.Remove(subscriber);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Subscriber> GetSubscriberByEmailAsync(string email)
        {
            return await _dbContext.Subscribers.FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task<Subscriber> GetSubscriberByIdAsync(int id)
        {
            return await _dbContext.Subscribers.FindAsync(id);
        }

        public async Task<IPagedList<Subscriber>> SearchSubscribersAsync(IPagingParams pagingParams, string keyword, bool unsubscribed, bool involuntary)
        {
            var query = _dbContext.Subscribers.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(s => s.Email.Contains(keyword));
            }

            if (unsubscribed)
            {
                query = query.Where(s => s.UnsubscribeDate != null);
            }

            if (involuntary)
            {
                query = query.Where(s => !s.IsUserInitiated);
            }

            var subscribers = await query.ToPagedListAsync(pagingParams.PageNumber, pagingParams.PageSize);

            return subscribers;
        }

        public async Task SubscribeAsync(string email)
        {
            var subscriber = new Subscriber
            {
                Email = email,
                RegistrationDate = DateTime.Now
            };

            _dbContext.Subscribers.Add(subscriber);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UnsubscribeAsync(string email, string reason, bool voluntary)
        {
            var subscriber = await GetSubscriberByEmailAsync(email);

            if (subscriber != null)
            {
                subscriber.UnsubscribeDate = DateTime.Now;
                subscriber.UnsubscribeReason = reason;
                subscriber.IsUserInitiated = voluntary;

                _dbContext.Subscribers.Update(subscriber);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
