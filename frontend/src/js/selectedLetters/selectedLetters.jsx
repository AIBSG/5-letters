import React from "react";
import AllLetters from "../freeLetters/freeLetters";
import styles from "./selectedLetters.module.css";
const SelectedLetters = () => {
    return (
        <div>
            <div className={styles.fullContainer}>
                <div className={styles.gameFieldFull}>
                    <div className={styles.gameField} style={{width: 325, fontSize: 32.6667} }>
                        <div className={styles.row}>
                            <div>Object</div>
                        </div>
                        <div className={styles.row}>
                            <div>Object</div>
                        </div>
                        <div className={styles.row}>
                            <div>Object</div>
                        </div>
                        <div className={styles.row}>
                            <div>Object</div>
                        </div>
                        <div className={styles.row}>
                            <div>Object</div>
                        </div>
                    </div>
                </div>
            </div>
            <AllLetters/>
        </div>
    )
}
export default SelectedLetters