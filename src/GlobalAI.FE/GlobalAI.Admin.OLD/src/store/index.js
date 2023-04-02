// store/index.js
import { createStore } from 'vuex';
import stack from './modules/stack';
import user from './modules/user';
import dichVu from './modules/dichVu';
import VuexPersist from 'vuex-persist';

const vuexLocalStorage = new VuexPersist({
    key: 'vuex', // The key to store the state on in the storage provider.
    storage: window.localStorage, // or window.sessionStorage or localForage
    // Function that passes the state and returns the state with only the objects you want to store.
    // reducer: state => state,
    // Function that passes a mutation and lets you decide if it should update the state in localStorage.
    // filter: mutation => (true)
  })

const store = createStore({
    modules: {
        stack,
        user,
        dichVu
    },
    plugins: [vuexLocalStorage.plugin]
})

export default store
