import { useState, useEffect } from "react";

interface Person
{
    firstName: string;
    lastName: string;
    age: number;
}

const people: Person[] = [
    {firstName: 'Peter', lastName: 'Smith', age: 21},
    {firstName: 'Dave', lastName: 'Jones', age: 21},
    {firstName: 'Pam', lastName: 'Adderson', age: 21},
    {firstName: 'Alice', lastName: 'Nicholas', age: 21},
    {firstName: 'Nick', lastName: 'Drake', age: 21}
];

function UseStateDependency(){
    const [val, setVal] = useState<number>(0);
    const [sqr, setSqr] = useState<number>(0);
    const [cube, setCube] = useState<number>(0);
    const [searchName, setSearchName] = useState<string>("");
    const [currentPerson, setCurrentPerson] = useState<Person | null>(null);

    function getPerson(val :string){
        const result = people.find(p => p.firstName === val) ?? null;
        if (result) 
            setCurrentPerson(result);
    }

    useEffect(() => {
        setSqr(val * val);
        setCube(Math.pow(val, 3));
    }, [val]);

    useEffect(() => {
        getPerson(searchName)
    }, [searchName]);

    return(
        <>
            <h5>Variable Dependency</h5>
            <p>Value: {val}</p>
            <p>Sqr: {sqr}</p>
            <p>Cube: {cube}</p>
            <button onClick={() => setVal(prev => prev + 1)}>+</button>

            <h5>Person Find</h5>
            <p><input
                type="text"
                value={searchName}                 
                onChange={e => setSearchName(e.target.value)} />
            </p>
            <p>{currentPerson?.firstName} {currentPerson?.lastName} {currentPerson?.age}</p>
        </>
    )
}

export default UseStateDependency;