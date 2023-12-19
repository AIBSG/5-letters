import React from "react";
import styles from "./navButton.module.css";
import questionMark from '../../images/questionMark.png'

const NavButtons = () => {
    return (
        <div className={styles.container}>
            <div className={styles.items}>
                <div className={styles.name}>Игра «5 Букв»</div>
                <div className={styles.buttons}>
                    <button className={styles.statsButton}>Моя статистика</button>
                    <button className={styles.howToPlay}>
                        <div className={styles.howToPlayText}>
                            Как играть
                        </div>
                        <div className={styles.howToPlayImg}>
                            <img  src={questionMark} alt="image"/>
                        </div>
                    </button>
                </div>
            </div>
        </div>
    )
}

export default NavButtons