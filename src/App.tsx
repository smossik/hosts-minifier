import React from 'react';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>Hosts-minifier</h1>
        <span>Upload a hosts file, the Hosts-minifier will concatenate lines.</span>
        <form className="file-upload">
          <label className="file-upload-label">
            <input id="file-upload-input" type="file" />
            <i className="fa fa-cloud-upload"></i> <span>File upload</span>
          </label>
          <label className="keep-comments">
            <input className="keep-comments-input" id="keep-comments-input" type="checkbox" />
            <i className="keep-comments-icon far fa-square"></i> <span>Keep comments</span>
          </label>
        </form>
      </header>
    </div>
  );
}

export default App;
