import React from "react";
import SelectedLetters from "../selectedLetters/selectedLetters";
import Header from "../header/header";
import styles from "./GameContainer.module.css"
const GameContainer = () => {
    return (
        <div className={styles.gameContainer} >
            <div>{<Header/>}</div>
            <div>{<SelectedLetters/>}</div>
        </div>
    )
}
export default GameContainer;