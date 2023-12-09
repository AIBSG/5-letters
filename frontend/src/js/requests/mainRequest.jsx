import React, {useEffect, useState} from "react";
import axios from "axios";
import AllLetters from "../freeLetters/freeLetters";

const src = 'https://content.guardianapis.com/search?page=2&q=debate&api-key=test'
const Request = () => {

   const [articles, setArticles] = useState([])

    useEffect(() => {
        axios
            .get(src)
            .then(data => {
                setArticles(data.data.response.results)
                console.log(data.data.response.results)
            })
    }, []);
    return (
        <div>
            {articles.map(article => {
                return (
                    <p>{article.webTitle}</p>
                );
            })}
        </div>
    )
}



export default Request
