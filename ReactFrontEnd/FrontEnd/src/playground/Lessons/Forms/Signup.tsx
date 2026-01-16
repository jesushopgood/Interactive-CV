import { useForm, type SubmitHandler } from "react-hook-form";


export default function Signup(){

    interface FormDetails {
        firstname : string;
        lastname : string;
        dob: Date;
        addressLine1: string;
        addressLine2: string;
        postcode: string;
        email: string;
        phone: string;
        password: string;
        confirmPassword: string;
    }

    const { register, handleSubmit, watch, formState: {errors} } = useForm<FormDetails>();
    const onSubmit: SubmitHandler<FormDetails> = (data) => {
        console.log(data);
    }

    const pwd = watch("password");
    
    return (
        <div className="d-flex justify-content-center align-items-center vh-100">
            <form onSubmit={handleSubmit(onSubmit)} className ="row g-3 p-4 border rounded bg-white shadow col-12 col-md-8">
                <h3 className="text-center mb-3">Sign Up</h3>

                <div className="col-md-6" >
                    <div className="mb-3">
                        <label htmlFor="firstname" className="form-label">First Name</label>
                        <input {
                            ...register("firstname", {
                                required: {
                                    value: true,
                                    message: "FirstName is required"
                                },
                                maxLength: {
                                    value: 30,
                                    message: "Name must be < 30 characters. "
                                }
                            })}
                            id="firstname"
                            placeholder="First name is required. "
                            className="form-control"
                        />
                    </div>
                    <div className="mb-3">
                        <label htmlFor="lastname" className="form-label">Last Name</label>
                        <input {
                            ...register("lastname", {
                                required: {
                                    value: true,
                                    message: "Lastname is required"
                                },
                                maxLength: {
                                    value: 40,
                                    message: "Last name must be < 40 character"
                                }
                            })}
                            id="lastname"
                            placeholder="Last name is required. "
                            className="form-control"
                        />
                    </div>
                    <div className="mb-3">
                        <label htmlFor="dob" className="form-label">Dob</label>
                        <input {
                            ...register("dob", {
                                required: {
                                    value: true,
                                    message: "Dob is required"
                                },
                                pattern: {
                                    value: /^(0[1-9]|[12][0-9]|3[01])\/(0[1-9]|1[0-2])\/[0-9]{4}$/,
                                    message: "Date must match the form DD/MM/yyyy" 
                                },
                            })}
                            id="dob"
                            placeholder="DD/MM/YYYY"
                            className="form-control"
                        />
                        { errors.dob && <p className="text-danger mt-1">{errors.dob.message}</p> }
                    </div>
                    <div className="mb-3">
                        <label htmlFor="addressLine1" className="form-label">Address Line1</label>
                        <input {
                            ...register("addressLine1", {
                                required: {
                                    value: true,
                                    message: "AddressLine1 is required"
                                },
                                maxLength: {
                                    value: 50,
                                    message: "Address cannot be longer than 50 characters"
                                }
                            })}
                            id="addressLine1"
                            placeholder="Address required"
                            className="form-control"
                        />    
                    </div>
                    <div className="mb-3">
                        <label htmlFor="addressLine2" className="form-label">Address Line2</label>
                        <input {
                            ...register("addressLine2", {
                                maxLength: {
                                    value:50,
                                    message: "Address cannot be longer than 50 characters"
                                }            
                            })}
                            id="addressLine2"
                            placeholder="optional"
                            className="form-control"
                        />
                    </div>
                    <div className="mb-3">
                        <label htmlFor="postcode" className="form-label">Postcode</label>
                        <input {
                            ...register("postcode", {
                                required: {
                                    value: true,
                                    message: "Postcode is required"
                                },
                                pattern: {
                                    value: /^([Gg][Ii][Rr] 0[Aa]{2}|(?![QVX])[A-Z]{1,2}[0-9][0-9A-Z]?\s?[0-9][A-Z]{2})$/,
                                    message: "Enter a valid UK postcode"
                                }
                            })}
                            id="postcode"
                            className="form-control"
                            placeholder="postcode is required"
                        />
                        { errors.postcode && <p className="text-danger mt-1">{errors.postcode.message}</p> }
                    </div>
                    <div className="mb-3">
                        <label htmlFor="email" className="form-label">Email</label>
                        <input {
                            ...register("email", {
                                required: {
                                    value: true,
                                    message: "Email is required"
                                },
                                pattern: {
                                    value: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
                                    message: "Enter a valid email address"
                                }
                            })}
                            id="email"
                            className="form-control"
                            placeholder="email is required"
                        />
                        {errors.email && <p className="text-danger mt-1">{errors.email.message}</p>}
                    </div>
                </div>

                <div className="col-md-6" >
                    
                    <div className="mb-3">
                        <label htmlFor="password" className="form-label">Password</label>
                        <input {
                            ...register("password", {
                                required: {
                                    value: true,
                                    message: "Password is required"
                                },
                                pattern: {
                                    value: /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/,
                                    message: "Password must be at least 8 characters, include upper & lower case, a number, and a special character"
                                }
                            })}
                            id="password"
                            className="form-control"
                            placeholder="enter a strong password"
                            type="password"
                        />
                        { errors.password && <p className="text-danger mt-1">{errors.password.message}</p>}
                    </div>
                    <div className="mb-3">
                        <label htmlFor="confirmPassword" className="form-label">Confirm Password</label>
                        <input {
                            ...register("confirmPassword", {
                                required: {
                                    value: true,
                                    message: "Must confirm your password"
                                },
                                validate: (value) => value === pwd || "Password do not match"
                            })}
                            id="confirmPassword"
                            className="form-control"
                            placeholder="confirm password"
                            type="password"
                        />
                        {errors.confirmPassword && <p className="text-danger mt-1">{errors.confirmPassword.message}</p>}
                    </div>
                    <ul>
                        {errors && Object.values(errors).map((err,idx) => <li key={idx} className="list-group-item">{err.message}</li>) }
                    </ul>            
                </div>
                
                <div className="d-flex justify-content-center">
                    <button type="submit" className="btn btn-primary w-50">Submit</button>
                </div>
            </form>
        </div>       
    )
}   