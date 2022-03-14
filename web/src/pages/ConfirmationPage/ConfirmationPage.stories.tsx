import React from 'react';

import {ComponentMeta, ComponentStory} from '@storybook/react';
import ConfirmationPage from "./ConfirmationPage";

export default {
    title: 'Pages/ConfirmationPage',
    component: ConfirmationPage,
    argTypes: {},
} as ComponentMeta<typeof ConfirmationPage>;

const Template: ComponentStory<typeof ConfirmationPage> = () => {
    return <ConfirmationPage />;
};

export const Default = Template.bind({});