import React from "react";
import SelectedLetters from "../selectedLetters/selectedLetters";
import styles from "./GameContainer.module.css"
import NavButtons from "../navButtons/navButtons";
import Keyboard from "../keyboard/keyboard";

const GameContainer = () => {
    return (
        <div className={styles.container}>
            <div className={styles.gameAndNav}>
                <NavButtons/>
                <SelectedLetters/>
            </div>
            <Keyboard/>
        </div>
    )
}
export default GameContainer;