export default function logger(state) {
  return (next) => (action) => {
    // eslint-disable-next-line no-console
    console.log('State', state.getState());
    // eslint-disable-next-line no-console
    console.log('Action', action);
    return next(action);
  };
}
