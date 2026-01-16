import { useForm, type SubmitHandler } from "react-hook-form";

export default function ReactHookForm(){
    
    type FormValues = {
        email: string;
        password: string;
    };

    const { register, handleSubmit, formState : { errors } } = useForm<FormValues>();

    const onSubmit : SubmitHandler<FormValues> = (data) => {
        console.log(data, errors);
    };

return(
    <form onSubmit={handleSubmit(onSubmit)}>
        <p>
            <input { ...register("email", {
                    required: "email is required",
                    pattern: {
                        value: /^\S+@\S+$/i,
                        message: "Email must be valid"
                    }
                })}
                placeholder="Enter email/username"
            />
        </p>
        <p>
            <input  
            { ...register("password", {
                required:"password is required",
                minLength:{
                    value:8,
                    message: "Password must be at least 8 characters. "
                },
                maxLength:{
                    value:20,
                    message: "Password must be at less than 20 characters. "
                }
            })}
            placeholder="Enter Password"
            />
        </p>
    
        <button type="submit">Submit</button>

        <ul style={{ color: "red" }}>
        {
            Object.values(errors).map((err, index) => <li key={index}>{err.message}</li>
        )}
      </ul>
    </form>
)}