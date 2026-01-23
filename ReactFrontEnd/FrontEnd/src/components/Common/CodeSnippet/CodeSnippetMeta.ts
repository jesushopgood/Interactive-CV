interface CodeSnippetMetaObject{
    title: string
    notes: string;
}

const codeSnippetMetaData: Map<string, CodeSnippetMetaObject> = new Map<string, CodeSnippetMetaObject>();

codeSnippetMetaData.set("SimpleClosures", {
    title: "Simple Closure",
    notes: "Uses getters and setter to change a closed variable."
});

codeSnippetMetaData.set("StaleClosures", {   
    title: "Stale Closures", 
    notes: "When the timeout is created. It uses the initla value of at the time of creation. not the updated value of increment." +  
    "Clicking the timer will increase the value of increment but the stale closure in the setTimeout only maintains the old value" 
});

codeSnippetMetaData.set("StaleEffect", {   
    title: "Stale UseEffect", 
    notes: "This component contains 3 useEffects.  The first shows the classic state effect which updates, but the console " +
            "shows the value is still zero internally.  The second has a dependency array so the stale effect issue doesnt occur" + 
            "The third uses the functional update approach \"setVal(prev => prev + 1)\"" 
});

codeSnippetMetaData.set("LiveClosure", {   
    title: "Live Closure", 
    notes: "JS doesnt store values in closures it stores references (pointers) to them, even if they are primitive. "
});

/*---------------------------------------------------Hooks Demo-----------------------------------------------------*/

codeSnippetMetaData.set("UseState", {   
    title: "useState()", 
    notes: "A basic form utilising the useState() hook for handling page state."
});

codeSnippetMetaData.set("UseReducer", {   
    title: "useReducer()", 
    notes: "A basic form utilising the useReducer() hook for complex data state handling. "
});

codeSnippetMetaData.set("UseRef", {   
    title: "useRef()", 
    notes: "Demostrates the correct use of a useRef() hook to simulate instance variables with causing re-render. " + 
        "Click Start to watch the race unfold."
});

codeSnippetMetaData.set("UseEffect", {   
    title: "useEffect()", 
    notes: "useEffect() is run after the component mount and render. Select a letter and complete the phrase inside the " +
            "number of permitted attempts. "
});

codeSnippetMetaData.set("UseMemo", {   
    title: "useMemo()", 
    notes: "useMemo() memoises a value.  In this case the login key is calculated from a hash that is an expensive operation"
});

codeSnippetMetaData.set("UseCallback", {   
    title: "useCallback()", 
    notes: "The combination of useCallback() to stablise a function and memo() to memoise a function allows the function to " +
        "not re-render automatically when the parent does unless it is requried to. "
});

codeSnippetMetaData.set("useDeferredValueClient", {   
    title: "useDeferredValue()", 
    notes: "This demo shows how useDeferredValue keeps the UI responsive when rendering thousands of items. " + 
    "The slider updates the actual value immediately, while the expensive badge list is driven by a deferred " +
    "version that intentionally lags behind. Toggling defer mode makes the difference clear: without it, every " + 
    "slider movement triggers a full re-render; with it, React delays the heavy work so the input stays smooth."

});

codeSnippetMetaData.set("UseTransitionClient", {   
    title: "useTransition()", 
    notes: "This example demonstrates how useTransition keeps typing responsive while filtering a large list. " +
    "Each keystroke updates the input immediately, but when transition mode is enabled, the expensive filtering work " +
    "is wrapped in a low‑priority update so React can delay it and skip intermediate renders. " +
    "The UI stays smooth even when filtering 20,000 items, and the built‑in isPending flag shows when React " + 
    "is still processing the transition."
});

codeSnippetMetaData.set("UseContext", {   
    title: "useContext()", 
    notes: "Demonstrates using a localised context to avoid prop dirlling.  Select a login from the drop down " + 
        "and the loaded user will be replicated through all levels of the component heirarchy. "
});
/*------------------------------------------Custom Hooks------------------------------------------------------*/

export default codeSnippetMetaData;

codeSnippetMetaData.set("UseDebounce", {   
    title: "Debouncing", 
    notes: "This debounce hook delays reacting to " +
            "fast‑changing input so the component only performs its search logic after the user pauses typing. " + 
            "Instead of filtering the product list on every keystroke, the hook waits for a quiet period " + 
            "(one second in this case) before updating the debounced value, reducing unnecessary work and making " +
            "the UI feel smoother and more intentional. E.G \"Type Chi quickly for an example\"" 
});

codeSnippetMetaData.set("UseSubscriber", {   
    title: "TV Subscription", 
    notes: "This custom subscription hook simulates a live TV feed by gradually revealing a channel’s message " +
            "at a speed determined by the user’s subscription tier. When the user selects a subscription and chooses " +
            "to “watch,” the hook streams the channel text character‑by‑character using a timed interval, " + 
            "resetting and looping the feed continuously. Changing the subscription or channel automatically " + 
            "adjusts the playback speed and content, creating a simple but fun real‑time viewing effect. " 
});

codeSnippetMetaData.set("UseThrottler", {   
    title: "TV Subscription",
    notes: "This is an example of a trailing throttler.  It limits the number of characters that can be typed within" + 
            " a timeinterval and only emits the last character." 
});

codeSnippetMetaData.set("UseSpeedType", {   
    title: "Speed Type Game",
    notes: "You’re shown a “master message,” and your only job is to type it perfectly from left to right into the text box. " + 
    "You’re not allowed to delete anything—pressing backspace ends the game instantly. " + 
    "If you type even a single wrong character, the game detects the exact word you messed up and " + 
    "ends the round. The game checks how many new characters you typed. If you typed fewer than the minimum required, you lose. " + 
    "If you keep up the pace and type accurately, the game encourages you and continues. " + 
    "When you restart, the game cycles to the next master message and resets your progress." 
});

codeSnippetMetaData.set("UseLocalStorage", {   
    title: "Local Storage hook",
    notes: "Abstract away the writing of values to localStorage using a custom hook. " 
});

codeSnippetMetaData.set("UsePrevious", {   
    title: "Previous hook",
    notes: "Utilises useRef abstract out the starge of a previous value. " 
});

codeSnippetMetaData.set("UseFetch", {   
    title: "Fetch Hook",
    notes: "Demonstrates a generic fetch hook to grab search results and individual records." 
});

codeSnippetMetaData.set("UseTimeoutInterval", {   
    title: "Timeout Interval Hook",
    notes: "A generic hook that lets you create a timeout or interval with cleanup logic." 
});

codeSnippetMetaData.set("StoreFrontUK.CustomersList", {   
    title: "Customers",
    notes: "Demonstrates calling StoreFront C# API with using AXIOS/ReactQuery and tanStack Headless UI Tables." 
});

codeSnippetMetaData.set("StoreFrontUK.CustomerDetail", {   
    title: "Customer",
    notes: "TBD" 
});

