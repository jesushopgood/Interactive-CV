import useWindowSize from "./useWindowSize";

export default function UseWindowClient(){
    const { width, height } = useWindowSize();

    return (
        <div className="container border border-primary p-2">
            <p>Width : {width} </p>
            <p>Height: {height} </p>
        </div>
    )
}