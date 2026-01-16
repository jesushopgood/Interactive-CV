import { useEffect, useState } from "react";
import type { Car } from "../entities/Car";
import { useNavigate } from "react-router-dom";

function CarList() {
  const [cars, setCars] = useState<Car[]>([]);
  const navigate = useNavigate();
  
  useEffect(() => {
    (async () => {
      try{
        const response = await fetch("http://localhost:5000/api/Car");
        const data = await response.json();
        setCars(data);
      }
      catch (ex){
        console.error(ex);
      }
    })()
  }, []);

  return (
    <div className="container mx-auto mt-4"> 
      {cars.map((car) => (
        <div key={car.id} className="card mb-3 shadow-sm row">
          <div className="card-body d-flex justify-content-between">
            <div className="col-md-3 fs-5">{car.manufacturer} {car.model}</div>
            <div className="text-primary fw-bold d-flex fs-3 col-md-2 justify-content-end">
              £{car.pricePerDay}/day
            </div>
            <div className="d-flex col-md-1 justify-content-end">
              <button className="btn btn-primary" onClick={() => navigate(`/Car/${car.id}`)}>Select</button>  
            </div>  
          </div>
        </div>
      ))}
    </div>  
  );
}

export default CarList;