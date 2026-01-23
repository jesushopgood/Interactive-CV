import CustomHooksWrapper, { CustomHooksWrapperActions } from "../components/CustomHooks/CustomHooksWrapper";
import HooksWrapper, { HooksWrapperActions } from "../components/HookDemo/HooksWrapper";
import { PropsWrapper, PropsWrapperActions } from "../components/MultiLevelProps/PropsWrapper";
import StoreFrontWrapper, { StoreFrontWrapperActions } from "../components/StoreFrontUK/StoreFrontWrapper";
import TsJsWrapper, { TsJsWrapperActions } from "../components/TS-JS/TsJsWrapper";
import type ComponentPathMapping from "../global-context/ComponentPathMapping";

export default function getInitialComponent(): ComponentPathMapping[]{
    const initialComponents = [
        {
            componentName: "PropsWrapper",
            component: <PropsWrapper />,
            menuActions: new PropsWrapperActions(),
            componentPath: "MultiLevelProps",
        },
        {
            componentName: "HooksWrapper",
            component: <HooksWrapper />,
            menuActions: new HooksWrapperActions(),
            componentPath: "HookDemo",
        },
        {
            componentName: "CustomHooksWrapper",
            component: <CustomHooksWrapper />,
            menuActions: new CustomHooksWrapperActions(),
            componentPath: "CustomHooks",
        },
        {
            componentName: "TsJsWrapper",
            component: <TsJsWrapper />,
            menuActions: new TsJsWrapperActions(),
            componentPath: "TS-JS",
        },
        {
            componentName: "StoreFrontWrapper",
            component: <StoreFrontWrapper />,
            menuActions: new StoreFrontWrapperActions(),
            componentPath: "StoreFrontUK",
        }

    ];

    return initialComponents;
}