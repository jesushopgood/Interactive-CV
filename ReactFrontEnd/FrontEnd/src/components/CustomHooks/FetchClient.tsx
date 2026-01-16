/* eslint-disable react-hooks/exhaustive-deps */
import { useEffect, useState } from "react";

interface UserSimple
{
    id: number
    firstName: string,
    lastName: string,
    maidenName: string,
    age: number,
    gender: string,
}

interface UserDisplayProps
{
    data: UserSimple[];
    userClicked: (id: number) => void;        
}

function UsersDisplay({data, userClicked} : UserDisplayProps){
    return (
        <div className="scroll-container">
            <ul className="list-group">
                {data.map(user => 
                    <button className="list-group-item list-group-item-action-blue" onClick={() => userClicked(user.id)}>
                        {user.id}: {user.firstName} {user.lastName}
                    </button>
                )}
            </ul>
        </div>
    )
}

function SingleUserDisplay({currentUser }: { currentUser: UserSimple}){
    return (
        <div className="container-fluid">
            <p><strong>{currentUser.firstName} {currentUser.lastName} Age: {currentUser.age} Gender: {currentUser.gender}</strong></p>
        </div>
    )
}

interface PaginatorFooterProps
{
    numberOfResults: number;
    currentPage: number;
    reload: (resultsPerPage: number, currentPage: number) => void;
}

interface PaginationResultProps
{
    numberOfResults: number;
    valueChanged: (newValue: number) => void;
}

function PaginationResults({ numberOfResults, valueChanged } : PaginationResultProps){
    const [resultsPerPage, setResultsPerPage] = useState(numberOfResults);

    const updateResultsPerPage = (val: number) => {
        setResultsPerPage(val);
        valueChanged(val);
    }

    return (
        <div className="d-flex justify-content-start gap-2 align-items-center" >
                <label htmlFor="results-per-page" className="form-label fs-6 mb-0">#Items</label>
                <input id="results-per-page" type="number" className="form-control" value={resultsPerPage} 
                    onChange={(e) => updateResultsPerPage(e.target.value === "" ? numberOfResults : parseInt(e.target.value)) }/>
        </div>
    )
}

interface PaginationPagerProps
{
    resultsPerPage: number;
    currentPageNumber: number;
    totalResults: number;
    pageChanged: (pageNumber: number, resultsPerPage: number) => void;
}

function PaginationPager({currentPageNumber, totalResults, resultsPerPage, pageChanged}: PaginationPagerProps){
    const totalPages = Math.ceil(totalResults / resultsPerPage);
    const pageArray:number[] = new Array(totalPages).fill(0).map((_, idx) => idx + 1);

    return (
        <div className="container d-flex justify-content-end align-items-center">
            { pageArray.map((val,idx) => (
                <button className="btn btn-link" key={idx+1} onClick={() => pageChanged(val, resultsPerPage)}>
                    { val === currentPageNumber ? <span className="fs-5"><strong>{val}</strong></span> : <span>{val}</span> }
                </button>
            ))}                   
        </div>
    )

}

function PaginationFooter({numberOfResults, currentPage, reload} : PaginatorFooterProps)
{
    const [resultsPerPage, setResultsPerPage] = useState(numberOfResults);
    const [pageNumber, setPageNumber] = useState(currentPage);
    const handleValueChanged = (val: number) => setResultsPerPage(val);
    const handlePageChanged = (pageNumber: number, resultsPerPage: number) => {
        setPageNumber(pageNumber);
        reload(resultsPerPage, pageNumber);
    } 

    return(
        <div className="container-fluid d-flex justify-content-between align-items-center">
            <PaginationResults numberOfResults={numberOfResults} valueChanged={handleValueChanged}/>  
            <PaginationPager currentPageNumber={pageNumber} resultsPerPage={resultsPerPage} totalResults={30} 
                                pageChanged={handlePageChanged} />      
         </div>
    ) 
}

function useFetch<T>(url: string | null){
     
    const [data, setData] = useState<T | null>(null);
    const [loading, setLoading] = useState(true);
    const [errorMessage, setErrorMessage] = useState<Error | null>(null);

    const load = async () => {
        try{
            if (!url) return;

            const res = await fetch(url);
            const json = await res.json();
            setData(json);
            setLoading(false);
        }
        catch(error){
            setErrorMessage(error as Error)
        }
    }

    useEffect(() => {
        load();
    }, [url]);

    return { data, errorMessage, loading };
}

//Start with an inline fetch using promise api
export default function FetchClient(){
    const baseUsersUrl = "https://dummyjson.com/users";
    
    const [usersUrl, setUsersUrl] = useState<string | null>(null);
    const [currentUserId, setCurrentUserId] = useState<number | null>(null);
    const [currentPageNumber, setCurrentPageNumber] = useState<number>(1);
    const [resultsPerPage, setResultsPerPage] = useState<number>(10);
 
    const buildResultsUrl = (resultsPerPage: number, currentPage: number) => {    
        return `${baseUsersUrl}?limit=${resultsPerPage}&skip=${(currentPage -1) * resultsPerPage}`;
    }

    useEffect(() => {
        setUsersUrl(buildResultsUrl(resultsPerPage, currentPageNumber));
    },[resultsPerPage, currentPageNumber])
    
    const { data: usersResult } = useFetch<{ users: UserSimple[] }>(usersUrl);
    const { data: currentUser} = useFetch<UserSimple>(currentUserId ? `${baseUsersUrl}/${currentUserId}` : null);
    
    const handleUserClicked = (id: number) => setCurrentUserId(id);
    
    const handleReload = async(resultsPerPage: number, pageNumber: number) => {
        setResultsPerPage(resultsPerPage);
        setCurrentPageNumber(pageNumber);
    }
    
    return (
        <div className="container-fluid">
            { currentUser && <SingleUserDisplay currentUser={currentUser} /> }
            { usersResult && <UsersDisplay data={usersResult.users} userClicked={(id) => handleUserClicked(id)} /> }
            { usersResult && resultsPerPage && currentPageNumber && 
                <PaginationFooter numberOfResults={resultsPerPage!} currentPage={currentPageNumber} reload={handleReload}/>
            }
        </div>
    ) 
}