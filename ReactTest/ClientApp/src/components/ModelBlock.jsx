import React from 'react';
import '../App.css'

const ModelBlock = ({children, isVisible, setVisible, setEdit}) => {

    const styleClasses = ["model"];

    if (isVisible) {
        styleClasses.push("modelActive");
        console.log("Из моджалки")
    }

    return (
        <div className={styleClasses.join(' ')} onClick={() => {setVisible(false); setEdit(false)}}>
            <div className="modelContent" onClick={(e) => e.stopPropagation()}>
                {children}
            </div>
        </div>
    );
};

export default ModelBlock;