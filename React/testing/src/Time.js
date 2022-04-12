import React from "react";

function Time(){
    const timeElement = (
        <div class="time">
            <h2>Current Time:{new Date().toLocaleTimeString()}.</h2>
        </div>
    )
    setInterval(timeElement,1000);
    return(timeElement);
}



export default Time;