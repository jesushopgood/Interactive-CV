import useTypewriter from "./useTypewriter";

export default function NoSelection () {
  const message = useTypewriter({text: "Select a menu item to load!! ", speed: 50});  
  return (
    <div className="container-fluid m-2">
        <h3 className="fs-6 text-uppercase text-danger">{message}</h3>
    </div>
  );
}
