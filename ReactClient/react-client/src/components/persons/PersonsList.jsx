import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import EntityTableItem from '../entitiesTable/EntityTableItem.jsx'
import { getPersonsAction, getPersonsCountAction } from '../../redux/actions.js'
import { connect } from 'react-redux';
import { countPages } from '../../util/PaginationHelper.js'
import { defValueChecker } from '../../util/SortingHelper.js'

class PersonsList extends React.Component {
  constructor(props) {
    super(props);
    this.state = { CurrentPage: 1, CurerentSort: "@PersonID" }
  }

  sortData(page, sort){
    const { selectPage, selectSort } =
      defValueChecker(page, sort, this.props.Pagination.CurrentPage, this.props.Pagination.CurrentSort);
    this.props.dispatch(getPersonsAction(selectPage, selectSort))
  }

  render() {
    const fields = ["PersonId", "FirstName", "LastName", "Phone"]
    if (!this.props.ItemsCount) {
      this.props.dispatch(getPersonsCountAction())
    }
    if (!this.props.Persons && this.props.ItemsCount) {

      this.props.dispatch(getPersonsAction(1))
    }

    const data = {
      Items: this.props.Persons,
      Pagination: this.props.Pagination,
      fields: fields,
      title: "person"
    }

    let totPages = countPages(this.props.ItemsCount)
    if (this.props.Persons && this.props.ItemsCount) {
      return (<EntityTableItem data={data} callback={this.sortData}
        CurrentPage={this.state.CurrentPage} CurrentSort={this.state.CurerentSort}
        TotalPages={totPages} />)
    }
    else {
      return (
        <div class="spinner-border" role="status">
          <span class="sr-only">Loading...</span>
        </div>
      );
    }
  }
}

const mapStateToProps = (state) => {
  return {
    Persons: state.Persons,
    Pagination: state.Pagination,
    ItemsCount: state.ItemsCount
  };
}

export default connect(mapStateToProps)(PersonsList) 