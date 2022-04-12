import React, { Component } from 'react';

class ProductClass extends Component {
    render() {
        //object destructuring
        const {name} = this.props;
        return (
            <div>
                <h1>Our new product:{name}</h1>
            </div>
        );
    }
}


export default ProductClass;