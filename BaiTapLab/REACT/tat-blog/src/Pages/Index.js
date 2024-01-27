import React, { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import PostItem from "../Components/PostItem";
import Pager from "../Components/Pager";
import { getPosts } from "../Services/BlogRepository";

const Index = () => {
    const [postItem, setPostItem] = useState([]);
    const [metadata, setMetadata] = useState({});

    function useQuery() {
        const { search } = useLocation();
        return React.useMemo(() => new URLSearchParams(search), [search]);
    }

    let query = useQuery(), k = query.get('k') ?? '', p = query.get('p') ?? 1, ps = query.get('ps') ?? 10;

    useEffect(() => {
        document.title = 'Trang chủ';

        getPosts(k, ps, p).then(data => {
            if (data) {
                setPostItem(data.items);
                setMetadata(data.metadata);
            }
            else
            {
                setPostItem([]);
            }
        })
    }, [k, p, ps]);

    useEffect(() => {
        window.scrollTo(0, 0);
    }, [postItem]);

    /*return (
        <h1>Đây là trang chủ</h1>
    );*/

    if (postItem.length > 0) {
        return (
            <div className="p-4">
                {postItem.map((item, index) => {
                    return (
                        <PostItem postItem={item} key={index}/>
                    );
                })};
                <Pager postquery={{ 'keyword': k }} metadata={metadata} />
            </div>
        );
    }
    else return (<></>);
}

export default Index;