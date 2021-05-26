import React, { useState, useEffect } from 'react';
import axios from 'axios';

const LakewoodScoopScraper = () =>{
    const [results, setResults] = useState([]);
    
useEffect(() =>{
  getResults()
  console.log(results);
    }, [])

const getResults = async() =>{
        const {data} = await axios.get('/api/scraper/scrape');
        setResults(data);

    }

    return(
        <div className="container" style={{ marginTop: 60 }}>
<h1>Welcome to the Lakewood Scoop</h1>
        <div className="row">
            <div className="col-md-12">
                {!!results.length && <table className="table table-header table-bordered table-striped table-hover">
                    <thead>
                        <tr>
                            <th style={{ width: "20%" }}>Image</th>
                            <th>Title</th>
                            <th>Blurb</th>
                            <th>Comment Count</th>
                        </tr>
                    </thead>
                    <tbody>
                        {results.map((result, idx) => <tr key={idx}>
                            <td>
                               <img src={result.image} style={{width:200}}/>
                            </td>
                            <td>
                                <a target="_blank" href={result.url}>
                                    {result.title}
                                </a>
                            </td>
                            <td>
                                {result.blurb}
                            </td>
                            <td>
                                {result.comments}
                            </td>
                        </tr>)}
                    </tbody>
                </table>}
            </div>
        </div>
    </div>
    )
}
export default LakewoodScoopScraper;