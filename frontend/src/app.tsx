import React from "react";

import MainContainer from "./js/mainComponent/mainContainer";
import {Provider} from "react-redux";
import {store} from "./store/store";



const App = () => {
    return (
        <Provider store={store}>
            <MainContainer/>
        </Provider>
    )

}

export default App;