import { useState, type ChangeEvent } from "react";

interface FormData
{
    firstname : string;
    lastname : string;
    age : number;
}

export default function SingleStateObject(){

    const [errors, setErrors] = useState<string[]>([]);

    const [formData, setFormData] = useState<FormData>({
        firstname: '',
        lastname: '',
        age: 0 
    });

     const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        
        const newErrors = [];

        if (!formData.firstname.length)
            newErrors.push(`First name must be set.`);
        if (!formData.lastname.length)    
            newErrors.push(`Last name must be set.`);
        if (!formData.age){
            newErrors.push(`Age must be set.`);    
        }

        setErrors(newErrors);
    };

    const handleChange = (e:ChangeEvent<HTMLInputElement>) =>
    {
        const { name, value } = e.target;
        setFormData((prev) => ({
            ...prev,
            [name] : name === 'age' ? Number(value) : value 
        }));
    }

    return (
        <>
            <form onSubmit= {handleSubmit}>
                <p>
                    <input  
                        type="input"
                        name="firstname"
                        value={formData?.firstname}
                        onChange={handleChange}
                        placeholder="First Name"
                    />
                </p>
                
                <p>
                    <input 
                        type="input"
                        name="lastname"
                        value={formData?.lastname}
                        onChange={handleChange}
                        placeholder="Last Name"
                    />
                </p>
                <p>
                    <input 
                        type="input"
                        name="age"
                        value={formData?.age}
                        onChange={handleChange}
                        placeholder="Age"
                    />
                </p>
                
                <button type="submit">Submit</button>    
            </form>
 
            {errors.length > 0 && (
                <ul style={{ color: "red" }}>
                    {errors.map((err, index) => (
                        <li key={index}>{err}</li>
                    ))}
                </ul>
            )}
        </>
    )
}