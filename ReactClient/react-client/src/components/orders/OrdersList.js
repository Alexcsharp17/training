import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import EntityTableItem from '../entitiesTable/EntityTableItem.js'
import { connect } from 'react-redux';
import { getOrdersAction, getOrdersCountAction } from '../../redux/actions.js'
import { countPages } from '../../util/PaginationHelper.js'
import { defValueChecker } from '../../util/SortingHelper.js'

class OrdersList extends React.Component {

  constructor() {
    super();
    this.state = { fetchData: "", fetchedItemsCount: "", CurrentPage: 1, CurerentSort: "@PersonID" }
  }

  sortData = (page, sort) => {
    const { selectPage, selectSort } = defValueChecker(page, sort, this.props.Pagination.CurrentPage, this.props.Pagination.CurrentSort);
    this.props.dispatch(getOrdersAction(selectPage, selectSort))
  }

  render() {
    const fields = ["OrderID", "OrderDate", "CarID", "PersonID"]
    if (!this.props.ItemsCount) {
      this.props.dispatch(getOrdersCountAction());
    }
    if (!this.props.Orders && this.props.ItemsCount) {
      this.props.dispatch(getOrdersAction(1))
    }

    if (this.props.Orders && this.props.ItemsCount) {
      const data = {
        Items: this.props.Orders,
        Pagination: this.props.Pagination,
        fields: fields,
        title: "order"
      }
      let totPages = countPages(this.props.ItemsCount)
      return (<EntityTableItem data={data} callback={this.sortData}
        CurrentPage={this.state.CurrentPage} CurrentSort={this.state.CurerentSort}
        TotalPages={totPages} />
      );
    }
    else {
      return (<div>Loading</div>);
    }
  }
}

const mapStateToProps = (state) => {
  return {
    Orders: state.Orders,
    Pagination: state.Pagination,
    ItemsCount: state.ItemsCount
  };
}

export default connect(mapStateToProps)(OrdersList)
