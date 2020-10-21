export default function defValueChecker(page, sort, defPage, defSort) {
  if (page === 'default' || !page) {
    page = defPage;
  }
  if (sort === 'default' || !sort) {
    sort = defSort;
  }

  return {
    selectPage: page,
    selectSort: sort,
  };
}
