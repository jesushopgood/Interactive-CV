import { Outlet, useLocation, useOutlet } from "react-router-dom";
import NoSelection from "./components/Common/NoSelection";
import { SlideOutPanel } from "./components/Menu/SlideOutPanel";
import { useStore } from "./state";

export default function Layout() {

  const outletElement = useOutlet();
  const location = useLocation();
  const getComponent = useStore(x => x.getComponent);
  const componentPathMapping = getComponent(location.pathname.slice(1))!;

  return (
    <div className="vh-75">
      <main className="container-fluid h-100 d-flex align-items-center">
        <div className="row w-100 content">
          <div className="col-12 col-md-9">
            <div className="card shadow">
              <div className="card-body p-1">
                {
                outletElement ? 
                  <Outlet /> :
                  <NoSelection />
                }
              </div>
            </div>
          </div>
          <div className="col-12 col-md-3">
            <SlideOutPanel componentPathMapping={componentPathMapping}/>                
          </div>
        </div>
      </main>
    </div>
  );
}
