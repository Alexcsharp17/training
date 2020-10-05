import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import SectionItem from '../dashboard/SectionItem.js'

const SECTIONS = [
    { title: 'Orders', href: '/orders' },
    { title: 'Persons', href: '/persons' }
]

class DashboardItem extends React.Component {
    render() {
        return (
            <div className="row mt-3 d-flex flex-row" >
                <div className="offset-3 col-6   adm_dash">
                    <div className="bg-dark text-white border rounded text-capitalize"><h4 className="text-center">Dashboard</h4></div>
                    <SectionItem href={SECTIONS[0].href} title={SECTIONS[0].title} />
                    <SectionItem href={SECTIONS[1].href} title={SECTIONS[1].title} />
                </div>
            </div>
        );
    }
}

export default DashboardItem