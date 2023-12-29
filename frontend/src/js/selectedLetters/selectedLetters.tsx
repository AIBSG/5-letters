import React from "react";
import Keyboard from "../keyboard/keyboard";
import NavButtons from "../navButtons/navButtons";
import styles from "./selectedLetters.module.css";
import {useAppSelector} from "../../hooks/storeHooks";


const SelectedLetters = () => {
    const {words} = useAppSelector(state => state.main)
    return (
        <div className={styles.container}>
            <div className={styles.fieldContainer}>
                <div className={styles.gameFieldFull}>
                    <div className={styles.gameField} >
                        {words.map((row, rowIndex) => {
                            return (
                                <div key={rowIndex} className={styles.row}>
                                    {row.map((letter, letterIndex) => {
                                        return (
                                            <div key={`${rowIndex}-${letterIndex}`}
                                                 className={styles.selectedLetterInRow}>
                                                  <span className={styles.selectedLetterSpan}>{letter.value ?? ''}</span>
                                            </div>
                                        )
                                    })}
                                </div>
                            )
                        })}
                    </div>
                </div>
            </div>
        </div>
    )
}
export default SelectedLetters