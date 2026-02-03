/* eslint-disable @typescript-eslint/no-explicit-any */
interface Segments 
{
    word: string ;
    parts: string[];
}

class StringHelper
{
    getWordAtPosition(sentence: string, index: number): string | undefined{
        if (index < 0 || index >= sentence.length) return undefined;

        let start = index;
        while (start > 0 && /\w/.test(sentence[start - 1])) {
            start--;
        }

        let end = index;
        while (end < sentence.length && /\w/.test(sentence[end])) {
            end++;
        }

        const word = sentence.slice(start, end);
        return word || undefined;
    }

    getDelimitedSegments(sentence: string, delimeter: string){

        const [startPos, endPos] = this.getDelimeterPosition(sentence, delimeter);
         
        if (startPos === -1 || endPos === -1) return sentence;

        let word = sentence.slice(startPos, endPos + 1);
        const parts = sentence.split(word);
        word = word.slice(1, word.length);

        return { word: word.replace("\"", ""), parts } as Segments;
    }

    getWordSegments(sentence: string, word: string, position: number){
        const start = sentence.lastIndexOf(" ", position) + 1;
        const end = sentence.indexOf(" ", position) - 1;
        return { word: `"${word}"`, parts: [sentence.slice(0, start), sentence.slice(end)]}
    }

    isSegment(x: string | Segments): x is Segments {
            return typeof x !== "string";
    }

    getByPath = (obj: any, path: string) => path.split('.').reduce((o, k) => o?.[k], obj);

    setByPath = <T>(obj: T, path: string, value: any): T => {
        const keys = path.split(".");
        const last = keys.pop()!;

        // clone the root
        const newObj: any = { ...obj };

        // walk and clone each level
        let curr = newObj;
        let original = obj as any;

        for (const key of keys) {
            curr[key] = { ...original[key] };
            curr = curr[key];
            original = original[key];
        }

        curr[last] = value;
    return newObj;
}

    private getDelimeterPosition(sentence: string, delimeter: string){
        const startPos = sentence.indexOf(delimeter);
        const endPos = sentence.lastIndexOf(delimeter);
        return [startPos, endPos];
    }
}

export { StringHelper, type Segments}