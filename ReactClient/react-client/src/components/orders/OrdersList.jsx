import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { connect } from 'react-redux';
import EntityTableItem from '../entitiesTable/EntityTableItem';
import { getOrdersAction, getOrdersCountAction } from '../../redux/actions';
import countPages from '../../util/PaginationHelper';
import  defValueChecker  from '../../util/SortingHelper';

class OrdersList extends React.Component {
  constructor() {
    super();
    this.state = { CurrentPage: 1, CurerentSort: '@PersonID' };
  }

  sortData=(page, sort)=> {
    const { selectPage, selectSort } = defValueChecker(page, sort,
      this.props.Pagination.CurrentPage, this.props.Pagination.CurrentSort);
    this.props.dispatch(getOrdersAction(selectPage, selectSort));
  }

  render(){
    const fields = ['OrderID', 'OrderDate', 'CarID', 'PersonID'];
    if (!this.props.ItemsCount) {
      this.props.dispatch(getOrdersCountAction());
    }
    if (!this.props.Orders && this.props.ItemsCount) {
      this.props.dispatch(getOrdersAction(1));
    }

    if (this.props.Orders && this.props.ItemsCount) {
      const data = {
        Items: this.props.Orders,
        Pagination: this.props.Pagination,
        fields,
        title: 'order',
      };
      const totPages = countPages(this.props.ItemsCount);
      return (
        <EntityTableItem
          data={data}
          callback={this.sortData}
          CurrentPage={this.state.CurrentPage}
          CurrentSort={this.state.CurerentSort}
          TotalPages={totPages}
        />
      );
    }

    return (<div>Loading</div>);
  }
}

const mapStateToProps = (state) => ({
  Orders: state.Orders,
  Pagination: state.Pagination,
  ItemsCount: state.ItemsCount,
});

export default connect(mapStateToProps)(OrdersList);
