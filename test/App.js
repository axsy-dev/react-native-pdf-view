/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 *
 * @format
 * @flow
 */

import React from 'react';
import PDFView from "react-native-pdf-view";
import {
  SafeAreaView,
  StyleSheet,
  View

} from 'react-native';



const App: () => React$Node = () => {

  return (
    <SafeAreaView style={styles.container}>
      <PDFView  src={`ms-appx:///Assets/pdf-test.pdf`}/>
    </SafeAreaView>     
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "whitesmoke"
  }
});

export default App;
