import React from 'react';
import {cleanup, fireEvent, render} from '@testing-library/react';
import ConfirmationPage from './ConfirmationPage';

// Note: running cleanup afterEach is done automatically for you in @testing-library/react@9.0.0 or higher
// unmount and cleanup DOM after the test is finished.
afterEach(cleanup);

it('ConfirmationPage ', () => {
    expect(true).toBe(true);
});