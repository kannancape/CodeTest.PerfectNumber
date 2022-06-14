




import React, { Component } from 'react';
import axios from 'axios';


class Integer extends Component {
   
    constructor(props) {
        super(props);
        this.state = {
           startNo:null,
           endNo:null
        };
    }
   
   
    onChange=(stateName,event)=>{
    this.setState({[stateName]:event.target.value})
    }
  submit=()=>{
    console.log('submit')


    axios.get(`https://192.168.8.222:5401/PerfectNumber? startNo=${this.state.startNo}& endNo=${this.state.endNo}`,{ headers: {"Access-Control-Allow-Origin": "*"}}).then((res)=>{
console.log(res)
    }).catch(err=>{
        console.log(err)
    })

    
  }
    render() {      
       const {startNo,endNo} =  this.state;  

        return (
            <div className='integer'>
                
               <strong>Start</strong>                     
               <input value={startNo} onChange={(event)=>this.onChange('startNo',event)}></input>
               <strong>End</strong>
               <input value={endNo} onChange={(event)=>this.onChange('endNo',event)}></input>
               <button onClick={()=>this.submit()}>Submit</button>
               
            </div>
        )


    }
}
export default Integer;