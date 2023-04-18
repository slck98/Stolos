// import React from 'react';
// import { Link } from 'react-router-dom';
// import driverClasses from '../css/DriverList.module.css';
// import logo from '../images/logoLong.png';


// const ListItem = ({props}) => {
//   return (
//     <header className={driverClasses.container}>
//     <article className={driverClasses.headerPage}>
//       <h1>Bestuurders</h1>
//       <img src={logo} alt="logo"></img>
//     </article>

//     <hr className={driverClasses.line} />
//     <ul>
//       {props.map(props => (
//         <li key={props.driverID.toString()}>
//           {console.log(props)}
//           <Link to={props.driverID.toString()}>{props.firstName}</Link>
//         </li>
//       ))}
//     </ul>
//   </header>
//   )
// }

// export default ListItem