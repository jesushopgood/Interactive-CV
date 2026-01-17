import { BrowserRouter, Routes, Route, NavLink } from "react-router-dom";
import Layout from "./Layout";
import "./app.scss";
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import 'bootstrap-icons/font/bootstrap-icons.css';
import { PropsWrapper } from "./components/MultiLevelProps/PropsWrapper";
import HooksWrapper from "./components/HookDemo/HooksWrapper";
import CustomHooksWrapper from "./components/CustomHooks/CustomHooksWrapper";
import TsJsWrapper from "./components/TS-JS/TsJsWrapper";
import { useStore } from "./state";
import StoreFrontWrapper from "./components/StoreFrontUK/StoreFrontWrapper";

function App() {

  const showAnnotations = useStore(x => x.showAnnotations);
  const toggleAnnotations = useStore(x => x.toggleAnnotations);     
  
  return (
      <BrowserRouter>
        <nav className="navbar navbar-vertical navbar-expand-lg bg-light">
          
          {/* Hamburger button */}
          
          <div className="container-fluid">
            <button
              className="navbar-toggler"
              type="button"
              data-bs-toggle="collapse"
              data-bs-target="#navbarNav"
              aria-controls="navbarNav"
              aria-expanded="false"
              aria-label="Toggle navigation">
                <span className="navbar-toggler-icon"></span>
            </button>
          </div>
          {/* Collapsible menu */}
          <div className="collapse navbar-collapse" id="navbarNav">
            <ul className="nav flex-column mt-3-rem list-group">
              <li className="my-1">
                <button className="btn btn-success text-uppercase" 
                  onClick={toggleAnnotations}>{showAnnotations ? 'Hide' : 'Show'} Annotations</button>
              </li>
              <li className="nav-item list-group-item my-1">
                <NavLink className="nav-link" to="PropsWrapper">Properties</NavLink>
              </li>
              <li className="nav-item list-group-item my-1">
                <NavLink className="nav-link" to="HooksWrapper">Hooks</NavLink>
              </li>
              <li className="nav-item list-group-item my-1">
                <NavLink className="nav-link" to="CustomHooksWrapper">Custom Hooks</NavLink>
              </li>
              <li className="nav-item list-group-item my-1">
                <NavLink className="nav-link" to="TsJsWrapper">Ts-Js</NavLink>
              </li>
              <li className="nav-item list-group-item my-1">
                <NavLink className="nav-link" to="StoreFrontWrapper">StoreFront</NavLink>
              </li>
            </ul>
          </div>
        </nav>
        <Routes>
          <Route path="/" element={<Layout/>}>
            <Route path="PropsWrapper" element={<PropsWrapper />} />
            <Route path="HooksWrapper" element={<HooksWrapper />} /> 
            <Route path="CustomHooksWrapper" element={<CustomHooksWrapper />} />
            <Route path="TsJsWrapper" element={<TsJsWrapper />} />
            <Route path="StoreFrontWrapper" element={<StoreFrontWrapper />} />    
          </Route>
        </Routes>
    </BrowserRouter>
  )
}

export default App
