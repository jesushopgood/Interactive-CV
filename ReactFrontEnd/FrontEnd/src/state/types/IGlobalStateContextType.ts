import type { IAnnotationType } from "./IAnnotationType";
import type ICodeMenuStateType from "./ICodeMenuStateType";
import type ICodeViewStateType from "./ICodeViewStateType";
import type IComponentStateType from "./IComponentStateType";

export default interface IGlobalStateContextType extends 
                                ICodeViewStateType, 
                                IComponentStateType,
                                ICodeMenuStateType,
                                IAnnotationType {}