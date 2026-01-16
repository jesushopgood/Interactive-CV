import { useState } from "react";
import type Employee from "../../entities/employee";

function YouseState(){

        const [colour, setColour] = useState<string>('red');
        const [employee, setEmployee] = useState<Employee | null>(null);
        // const [isOn, setIsOn] = useState<boolean>(false);
        const newEmployee: Employee = { firstname: 'Peter', lastname: 'Hopgood', age : 53, isBritish : true };   
 
        const updateColour = () =>{
            setColour(colour === 'red' ? 'blue' : 'red');
        }

        const toggleIsOn = () => {
            setIsOn(!isOn);
        }

        const updateLastName = (newName: string) => {
            setEmployee(previousState => {
                return previousState ? { ...previousState, lastname: newName} : null;
            });
        }
        
        const updateAge = (newAge: number) => {
            setEmployee(previousState => {
                return previousState ? { ...previousState, age : newAge } : null;
            });
        }

        const updateFirstName = (newName: string) => {
            setEmployee(previousState => previousState ? { ...previousState, firstname: newName}: null);
        }

        return (
            <> 
                <h4>Colour</h4> 
                <p><button onClick={updateColour}>Change colour</button></p>
                <p><em>{colour}</em></p>

                <h4>Employee</h4>
                <button onClick={() => setEmployee(newEmployee)}>Set Employee</button>    
                <div>{employee?.firstname ?? ''} {employee?.lastname ?? ''} {employee?.age ?? 'n/a'} </div>

                <h5>Partial Set...</h5>
                <div>
                    <button onClick={() => updateLastName('Jackson')}>
                        Set Name
                    </button>
                </div>
                <div>
                    <button onClick={() => updateAge(18)}>
                        Set Age
                    </button>    
                </div>
                <div>
                    <button onClick={() => updateFirstName('Stan')}>
                        Set First Name
                    </button>
                </div>
                <>
                    <button onClick={() => toggleIsOn()}>Toggle { isOn.toString() }</button>
                </>
            </>
        )
}

export default YouseState;