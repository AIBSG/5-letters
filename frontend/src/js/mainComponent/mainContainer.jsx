import React from "react";
import GameContainer from "../components/GameContainer";
import styles from "./mainContainer.module.css"
import Header from "../header/header";

const MainContainer = () =>{
    return (
        <div className={styles.mainContainer}>
            <Header/>
            <GameContainer/>
        </div>
    )
}
export default MainContainer