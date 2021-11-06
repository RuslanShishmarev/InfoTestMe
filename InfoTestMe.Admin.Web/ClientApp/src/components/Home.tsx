import * as React from 'react';
import { connect } from 'react-redux';

const Home = () => (
  <div>
    <h1>Create course and tests</h1>
    <p>Welcome to your admin page.</p>
  </div>
);

export default connect()(Home);
