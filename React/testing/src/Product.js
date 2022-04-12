import React from "react";

function Product(props){
    return (
        <div class="propsStyle">
            <table>
                    
                    <tr class="firstRow">
                        <td>Product Name</td>
                        <td>Brand</td>
                        <td>Price</td>
                    </tr>
                    <tr>
                        <td>{props.name}</td>
                        <td>{props.brand}</td>
                        <td>{props.price}</td>
                    </tr>
                   
            </table>
            
        </div>
    )
}

export default Product