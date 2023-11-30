import React from "react";
import GameContainer from "../components/GameContainer";
import styles from "./mainContainer.module.css"
const MainContainer = () =>{
    return (
        <div className={styles.mainContainer}>
            <GameContainer/>
        </div>
    )
}
export default MainContainer