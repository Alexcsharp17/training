import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';

export default class PageLinks extends React.Component {
  constructor(props) {
    super(props);
    this.props = props;
  }

  rendPrevButton() {
    if (this.props.CurrentPage === 1) {
      return <button type="button" onClick={() => this.GoToPage(this.props.CurrentPage - 1)} disabled className="btn border">{'<<'}</button>;
    }

    return <button type="button" onClick={() => this.GoToPage(this.props.CurrentPage - 1)} className="btn border">{'<<'}</button>;
  }

  rendNextButton() {
    if (this.props.CurrentPage === this.props.TotalPages) {
      return <button type="button" onClick={() => this.GoToPage(this.props.CurrentPage + 1)} disabled className="btn border">{'>>'}</button>;
    }

    return <button type="button" onClick={() => this.GoToPage(this.props.CurrentPage + 1)} className="btn border">{'>>'}</button>;
  }

  formPagesList() {
    const pages = [];
    if (this.props.TotalPages < 6) {
      for (let i = 1; i < this.props.TotalPages; i += 1) {
        pages.push(i);
      }
    } else if (this.props.CurrentPage <= 6) {
      for (let i = 1; i <= 6; i += 1) {
        pages.push(i);
      }
    } else if (this.props.TotalPages - this.props.CurrentPage < 6) {
      for (let i = this.props.TotalPages - 6; i <= this.props.TotalPages; i += 1) {
        pages.push(i);
      }
    } else {
      for (let i = this.props.CurrentPage - 2; i < this.props.CurrentPage + 2; i += 1) {
        pages.push(i);
      }
    }
    return pages;
  }

  GoToPage(page) {
    this.props.callback(page, 'default');
  }

  render() {
    const pages = this.formPagesList();
    return (
      <div>
        {this.rendPrevButton()}
        { pages.map((pg) => {
          let buton = 'btn border';
          buton += this.props.CurrentPage === pg ? ' btn-primary' : ' btn-default';
          return <button type="button" onClick={() => this.GoToPage(pg)} className={buton}>{pg}</button>;
        })}
        {this.rendNextButton()}
      </div>
    );
  }
}
