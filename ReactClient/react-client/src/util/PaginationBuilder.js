import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';

export class PageLinks extends React.Component {
    constructor(props) {
        super(props)
        this.props=props;
        this.state= { 
            TotalPages: props.TotalPages,
            CurrentPage:this.props.page,
            PrevButtonState:"",
            NextButtonState:""
            };

    }
    rendPrevButton = () => {
        if (this.props.CurrentPage == 1) {
            return <button onClick={() => this.GoToPage(this.props.CurrentPage - 1)} disabled className="btn border">{"<<"}</button>
        }
        else {
            return <button onClick={() => this.GoToPage(this.props.CurrentPage - 1)}  className="btn border">{"<<"}</button>
        }
    }

    rendNextButton = () => {
        if (this.props.CurrentPage == this.props.TotalPages) {
            return <button onClick={() =>this.GoToPage(this.props.CurrentPage + 1)} disabled className="btn border">{">>"}</button>
        }
        else {
            return <button onClick={() =>this.GoToPage(this.props.CurrentPage + 1)} className="btn border">{">>"}</button>
        }
    }

    formPagesList=()=>{
        let pages = [];
        if (this.props.TotalPages < 6) {
            for (let i = 1; i < this.props.TotalPages; i++) {
                pages.push(i);
               
            }
        } //if we are at the begining
        else if (this.props.CurrentPage <= 6) {
            for (let i = 1; i <= 6; i++) {
                pages.push(i);
            }
        }//if we are in the end
        else if (this.props.TotalPages - this.props.CurrentPage < 6) {
            for (let i = this.props.TotalPages - 6; i <= this.props.TotalPages; i++) {
                pages.push(i);
            }
        }//if we are at the middle
        else {
            for (let i = this.props.CurrentPage - 2; i < this.props.CurrentPage + 2; i++) {
                pages.push(i);
            }
        }
        return pages;
    }

    render() {
        console.log("Total pages", this.state.TotalPages)
        let pages = this.formPagesList();      
        return (
            <div>
                {this.rendPrevButton()}
                { pages.map((pg) => {
                   let buton="btn border"
                    buton += this.props.CurrentPage==pg?" btn-primary":" btn-default";
                    return <button onClick={() => this.GoToPage(pg)} className={buton}>{pg}</button>
                })}
                {this.rendNextButton()}
            </div>
        )
    }
    GoToPage(page) {
        this.props.callback(page,"default");
    }
}

