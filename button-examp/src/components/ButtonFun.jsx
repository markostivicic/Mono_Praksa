import React from 'react';
import Button from '@mui/material/Button';

export default function ButtonFun(prop) {

        return(
        <Button variant="contained" style={{margin:"20px"}} onClick={prop.onClick}>{prop.text}</Button>

        );
}
