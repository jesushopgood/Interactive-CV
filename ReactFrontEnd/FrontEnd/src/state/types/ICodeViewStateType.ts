export default interface ICodeViewStatetType
{
    openCodeView: () => void;
    closeCodeView: () => void;
    toggleCodeView: () => void;
    isCodeViewOpen: boolean;
}