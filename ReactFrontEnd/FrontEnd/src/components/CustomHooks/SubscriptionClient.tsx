import { useEffect, useRef, useState } from "react";

const subscriptions = new Map<string, number>();
subscriptions.set("Free", 500);
subscriptions.set("Gold", 800);
subscriptions.set("Premium", 1000);

const channels = new Map<number, string>();
channels.set(1, "CH1: You are watching Channel 1 at the moment.  Please Enjoy!!");
channels.set(2, "CH2: This is Channel 2.  We are proud to have no adverts. ");
channels.set(3, "CH3: Youre watching Channel 3.  The football will start shortly. ");
channels.set(4, "CH4: This is Channel 4! Please watch resposibly.");
    
function useSubscription(subscriptionType: string, watchNow: boolean = false, currentChannel: number = 1){   
    const [currentFeed, setCurrentFeed] = useState("");
    const counter = useRef(1);

    useEffect(() => {
        
        const message = channels.get(currentChannel) ?? "";
        if (!subscriptionType || !watchNow) return;

        const id = setInterval(() => {
            
            if (counter.current < message.length)
                setCurrentFeed(message.slice(0, counter.current++));
            else
                counter.current = 1;

        }, Math.max(100, 1100 - subscriptions.get(subscriptionType)!))
        
        return () => clearInterval(id);
    }, [subscriptionType, currentChannel, watchNow]);

    return currentFeed;
}

export default function SubscriptionClient(){
    const [currentSubscription, setCurrentSubscription] = useState("");
    const [watchNow, setWatchNow] = useState(false);
    const [channel, setChannel] = useState(1);

    const tvDisplay = useSubscription(currentSubscription, watchNow, channel);
    
    const handleClick = (e: React.FormEvent<HTMLButtonElement>, subscriptionType: string) => {
        setCurrentSubscription(subscriptionType);
        e.preventDefault();
    }

    const updateWatchNow = (e: React.FormEvent<HTMLButtonElement>) => {
        e.preventDefault();
        setWatchNow(prev => !prev);
    }

    const updateChannel = (e: React.FormEvent<HTMLButtonElement>, channel: number) => {
        e.preventDefault();
        setChannel(channel);
    }

    return(
        <div className="container-fluid">
            <form>
                <div className="mb-3">
                    {currentSubscription && <p>{currentSubscription} is {watchNow ? "Live" : "Paused"}</p>}
                    <label htmlFor="television-window" className="form-label" />
                    <textarea className="form-control" id="television-window" value={tvDisplay} readOnly />
                </div>
                <div className="mb-3 d-flex justify-content-between">
                    <button className="btn btn-primary btn-sm m-2" onClick={(e) => handleClick(e, "Premium")}>Premium</button>
                    <button className="btn btn-secondary btn-sm m-2" onClick={(e) => handleClick(e, "Gold")}>Gold</button>
                    <button className="btn btn-success btn-sm m-2" onClick={(e) => handleClick(e, "Free")}>Free</button>
                </div>
                { currentSubscription &&
                    <div className="mb-3 d-flex justify-content-center">
                        <button className="btn btn-danger" 
                            onClick={(e) => updateWatchNow(e)}>{watchNow ? "Pause" : "Watch Now!"}
                        </button>
                    </div>
                }
                { currentSubscription && watchNow &&
                    <>
                        <h5>Channels</h5>
                        <div className="mb-3 d-flex justify-content-start">
                            <button className="btn btn-sm btn-primary m-2" onClick={(e) => updateChannel(e, 1)}>One</button>
                            <button className="btn btn-sm btn-secondary m-2" onClick={(e) => updateChannel(e, 2)}>Two</button>
                            <button className="btn btn-sm btn-success m-2" onClick={(e) => updateChannel(e, 3)}>Three</button>
                            <button className="btn btn-sm btn-danger m-2" onClick={(e) => updateChannel(e, 4)}>Four</button>
                        </div>
                    </> 
                }
            </form>
        </div>
    )
}