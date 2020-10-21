export default function countPages(totalItems) {
  return totalItems % 5 !== 0 ? (Math.trunc(totalItems / 5)) + 1 : Math.trunc(totalItems / 5);
}
