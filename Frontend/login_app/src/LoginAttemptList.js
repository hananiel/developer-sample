import React, { useId } from "react";
import "./LoginAttemptList.css";
import { useState } from 'react'

const LoginAttempt = (props) => <li {...props}>{props.children}</li>;
const LoginAttemptList = (props) => {
	const [filter, setfilter] = useState('');
	return (
		<div className="Attempt-List-Main">
			<p>Recent activity</p>
			<input type="input" placeholder="Filter..." onChange={event => setfilter(event.target.value)} />
			<ul className="Attempt-List">
				{props.attempts
					.filter(f => f.includes(filter) || f === '').map((attempt, id) =>
					<LoginAttempt key={id} >{attempt} logged in successfully. </LoginAttempt>
				)}
			</ul>
		</div>
	)
};

export default LoginAttemptList;