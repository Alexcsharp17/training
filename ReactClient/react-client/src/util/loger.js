export function logger(state) {
    return function (next) {
        return function (action) {
            console.log("State", state.getState());
            console.log("Action", action);
            return next(action);
        }
    }
}