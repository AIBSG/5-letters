import React from "react";
import styles from "./freeLetters.module.css"
const findButton = (event) => {
    console.log(event.target)
}
const arrayOne = ['й','ц','у','к','е','н','г','ш','щ','з','х','ъ']
const arrayTwo = ['ф','ы','в','а','п','р','о','л','д','ж','э']
const arrayThree = ['OK','я','ч','с','м','и','т','ь','б','ю','BACKSPACE']
const AllLetters = () => {
    return (
        <div className={styles.keyboard}>
            <div className={styles.container}>
                {arrayOne.map((letter) => {
                    return <button className={styles.buttons} onClick={findButton}>{letter}</button>
                })}
            </div>
            <div className={styles.container}>
                {arrayTwo.map((letter) => {
                    return <button className={styles.buttons} onClick={findButton}>{letter}</button>
                })}
            </div>
            <div className={styles.container}>
                {arrayThree.map((letter) => {
                    return <button className={styles.buttons} onClick={findButton}>{letter}</button>
                })}
            </div>
        </div>
    );
};
export default AllLetters;