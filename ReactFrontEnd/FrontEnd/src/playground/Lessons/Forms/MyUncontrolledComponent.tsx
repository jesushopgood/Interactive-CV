import { useRef, useState } from "react";

export default function MyUncontrolledComponent(){
    
  const nameRef = useRef<HTMLInputElement>(null);
  const ageRef = useRef<HTMLInputElement>(null);

  const [currentName, setCurrentName] = useState("");
  const [currentAge, setCurrentAge] = useState("");

  const handleSubmit = () => {
    setCurrentName(nameRef.current?.value ?? "");
    setCurrentAge(ageRef.current?.value ?? "");
  };

  return (
    <>
      <p>
        <input type="text" ref={nameRef} />
      </p>

      <p>
        <input type="text" ref={ageRef} />
      </p>

      <button onClick={handleSubmit}>Submit</button>

      <p>current name: {currentName}</p>
      <p>current age: {currentAge}</p>
    </>
  );  
}