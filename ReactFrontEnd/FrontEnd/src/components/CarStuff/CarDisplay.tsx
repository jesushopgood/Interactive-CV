import { useParams } from "react-router-dom"; 
import type { Car } from "../entities/Car";
import { useEffect, useState } from "react";

function CarDisplay(){
    const [car, setCar] = useState<Car | null>(null);
    const { id } = useParams();

    useEffect(() => {
        (async () => {
            try{
                const response = await fetch(`http://localhost:5000/api/car/${id}`);
                const data = await response.json();
                setCar(data);
            }
            catch(ex){
                console.error(ex);
            }
        })();
    }, [id]);

    function setOutput() {
        if (car !== null){
            return (
                <div>    
                    <div>id from params : { id }</div>
                    <div>I am Car: { car.manufacturer } - { car.model }</div>
                </div>
            );
        }
        else{
            return <div>No Car was found</div>
        }
    }

    return (
        <>
            { setOutput() }     
        </> 
    );
}

export default CarDisplay;