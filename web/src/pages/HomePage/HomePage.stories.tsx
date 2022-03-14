import React from 'react';

import {ComponentMeta, ComponentStory} from '@storybook/react';
import HomePage from "./HomePage";

export default {
    title: 'Pages/HomePage',
    component: HomePage,
    argTypes: {},
} as ComponentMeta<typeof HomePage>;

const Template: ComponentStory<typeof HomePage> = () => {
    return <HomePage />;
};

export const Default = Template.bind({});